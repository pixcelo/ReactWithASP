# React + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react/README.md) uses [Babel](https://babeljs.io/) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh


## vite.config.js
`vite.config.js`は、Viteのビルド設定を行うための設定ファイル
- Viteの開発サーバーの設定を行う
- ビルド時のオプションを設定する
- エントリーポイントの指定
- 出力ファイル名の設定
- ライブラリモードの設定
- 環境変数の設定
- プラグインの追加
- エイリアスの設定
- ポリフィルの設定
```js
// Node.jsのモジュールをインポート
import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import fs from 'fs';
import path from 'path';
import child_process from 'child_process';
import { env } from 'process';

// 証明書とキーファイルの配置フォルダを決定
const baseFolder =
    env.APPDATA !== undefined && env.APPDATA !== ''
        ? `${env.APPDATA}/ASP.NET/https`
        : `${env.HOME}/.aspnet/https`;

const certificateName = "reactwithasp.client";
const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

// 証明書とキーファイルが存在しない場合、新しく生成する
if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    if (0 !== child_process.spawnSync('dotnet', [
        'dev-certs',
        'https',
        '--export-path',
        certFilePath,
        '--format',
        'Pem',
        '--no-password',
    ], { stdio: 'inherit', }).status) {
        throw new Error("Could not create certificate.");
    }
}

// HTTPSサーバーのターゲットURLを設定
const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7149';

// https://vitejs.dev/config/
export default defineConfig({
    // Reactプラグインを設定
    plugins: [plugin()],
    resolve: {
        // `@`エイリアスを`./src`に設定
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        // `/weatherforecast`へのリクエストをHTTPSサーバーにプロキシする
        proxy: {
            '^/weatherforecast': {
                target,
                secure: false
            }
        },
        // 開発サーバーのポート番号を5173に設定
        port: 5173,
        // 生成または読み込んだ証明書とキーファイルを設定してHTTPSサーバーを起動
        https: {
            key: fs.readFileSync(keyFilePath),
            cert: fs.readFileSync(certFilePath),
        }
    }
})
```

### APS.NET CoreのAPI設定は server.proxy にて行う
`^/api/*`と設定<br/>
`target`にプロキシの転送先URLを指定する
```js
server: {        
        proxy: {
            '^/weatherforecast': {
                target,
                secure: false
            },
            '^/api/exampleEndpoint': {
                target,
                secure: false
            }
        },
        
    }
```
その他の設定は、[公式ドキュメント](https://vitejs.dev/config/server-options.html#server-proxy)を参照
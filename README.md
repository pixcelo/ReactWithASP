# React-With-ASP.NET


GET `https://localhost:5173/api/test`

```js
server: {
        proxy: {
            '^/weatherforecast': {
                target,
                secure: false
            },
            // '^/api/test': {
            //     target,
            //     secure: false
            // },
        },
        port: 5173,
        https: {
            key: fs.readFileSync(keyFilePath),
            cert: fs.readFileSync(certFilePath),
        }
    }
```

## Reference
- [チュートリアル: Visual Studio での React を使用した ASP.NET Core アプリの作成](https://learn.microsoft.com/ja-jp/visualstudio/javascript/tutorial-asp-net-core-with-react?view=vs-2022)
- [ASP.NET Core でのシングルページ アプリケーション (SPA) の概要](https://learn.microsoft.com/ja-jp/aspnet/core/client-side/spa/intro?view=aspnetcore-8.0#developing-single-page-apps)
- [freeCodeCamp.org … React with .NET Web API – Basic App Tutorial](https://www.youtube.com/watch?v=4RKuyp_bOhY) … .NET6
- [Login & Registration using .Net 8 Authentication with Custom Identity. React + Web API Project](https://www.youtube.com/watch?v=DK7YAqd0tJA&t=125s)  … .NET8
- [Identity を使用して SPA の Web API バックエンドをセキュリティで保護する方法](https://learn.microsoft.com/ja-jp/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-8.0)
- [Web API 規約を使用する](https://learn.microsoft.com/ja-jp/aspnet/core/web-api/advanced/conventions?view=aspnetcore-8.0)
import React from 'react';

const Button = ({
    onClick,
    children
}: {
    onClick: () => void;
    children: React.ReactNode
}) => {
    return (
        <button onClick={onClick}>
            {children}
        </button>
    );
};

export default Button;

/*
    1. Buttonコンポーネントを作成し、propsとしてonClickとchildrenを受け取る
    2. Buttonコンポーネントは、onClickプロパティに渡された関数をボタンがクリックされたときに実行する
    3. ボタンの中身はchildrenプロパティに渡された値を表示する

    このオブジェクトは、Reactコンポーネントのprops（プロパティ）を定義している
    ※具体的には、Button コンポーネントが受け取るpropsを定義

    {
        onClick,
        children
    }: {
        onClick: () => void;
        children: React.ReactNode
    }

    children: React.ReactNode; は、children という名前のpropsがReactノードであることを示す
    ※ReactノードはReactがレンダリングできる任意のオブジェクト

    文字列、数値、Reactコンポーネント、HTML要素、またはそれらの配列など、
    Reactがレンダリングできる任意の要素を含むことができる
*/
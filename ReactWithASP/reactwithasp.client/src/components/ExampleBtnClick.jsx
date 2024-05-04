const ExampleBtnClick = () => {
    const clickHandler = () => {
        alert('Button clicked.');
    }

    return (
        <>
            <button onClick={clickHandler}>click me</button>
        </>
    );
};

export default ExampleBtnClick;
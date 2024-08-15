window.initializeKeyEvent = (dotnetHelper) => {
    document.getElementById('myInput').addEventListener('keydown', function (event) {
        if (event.key === 'Enter') {
            dotnetHelper.invokeMethodAsync('OnEnterKeyPressed');
        }
    });
};

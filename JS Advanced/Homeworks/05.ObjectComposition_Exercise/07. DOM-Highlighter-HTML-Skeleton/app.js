function domTraversal(selector) {
    const element = document.querySelector(selector);

    // element.classList.add('highlight');
    // highlightChildren(element);
    // function highlightChildren(element) {
    //     const children = element.children;
    //     for (let i = 0; i < children.length; i++) {
    //         highlightChildren(children[i]);
    //         children[i].classList.add('highlight');
    //     }
    // }

    (function changeClass(element) {
        if (element.hasChildNodes()) {
            element.className += ' highlight';
            changeClass(Array.from(element.childNodes)
                .sort((a, b) => b.childNodes.length - a.childNodes.length)[0]);
        }
    })(element);
}

domTraversal('#content');
function addItem() {
    const input = document.getElementById('newText');
    const ul = document.getElementById('items');
    const newLi = createElement('li', input.value + ' ');

    const aEleAttr = { name: 'href', value: '#' };
    const aEleEventListener = { type: 'click', func: deleteItem };
    const deleteLink = createElement('a', '[Delete]', aEleAttr, aEleEventListener);

    appendChilds(newLi, [deleteLink]);
    appendChilds(ul, [newLi]);

    clearText(input);

    function deleteItem() { ul.removeChild(this.parentNode); }

    function createElement(tagElement, text, attr, eListener) {
        const element = document.createElement(tagElement);
        element.textContent = text;
        if (attr) element.setAttribute(attr.name, attr.value);
        if (eListener) element.addEventListener(eListener.type, eListener.func);

        return element;
    }

    function clearText(element) { element.value = ''; }

    function appendChilds(parent, childs) {
        childs.forEach((child) => parent.appendChild(child));
    }
}
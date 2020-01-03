function extensibleObject() {
    const оbj = {
        __proto__: {},
        extend: function (template) {
            for (const propertyName of Object.getOwnPropertyNames(template)) {
                if (typeof (template[propertyName]) === 'function') {
                    Object.getPrototypeOf(this)[propertyName] = template[propertyName];
                } else {
                    this[propertyName] = template[propertyName];
                }
            }
        }
    };    

    return оbj;
}

const template =  {
    extensionMethod: () => {
        console.log("From extension method");
    },
    extensionProperty: 'someString'
};

let testObj = extensibleObject();
testObj.extend(template);
console.log(testObj);
console.log(Object.getPrototypeOf(testObj));
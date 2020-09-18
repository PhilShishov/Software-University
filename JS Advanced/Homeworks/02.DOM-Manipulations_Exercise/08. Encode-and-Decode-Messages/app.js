function encodeAndDecodeMessages() {
    function encodeAndSend() {
        const message = receiverTextarea.value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            let newCharCode = message[i].charCodeAt(0) + 1;
            encodedMessage += String.fromCharCode(newCharCode);
        }

        receiverTextarea.value = '';
        senderTextarea.value = encodedMessage;
    }

    function decodeAndRead() {
        const message = senderTextarea.value;
        let decodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            let newCharCode = message[i].charCodeAt(0) - 1;
            decodedMessage += String.fromCharCode(newCharCode);
        }

        senderTextarea.value = decodedMessage;
    }

    let receiverTextarea = document.getElementsByTagName('textarea')[0];
    let senderTextarea = document.getElementsByTagName('textarea')[1];

    const encodeAndSendButton = document.getElementsByTagName('button')[0];
    encodeAndSendButton.addEventListener('click', encodeAndSend);

    const decodeAndReadButton = document.getElementsByTagName('button')[1];
    decodeAndReadButton.addEventListener('click', decodeAndRead);
}
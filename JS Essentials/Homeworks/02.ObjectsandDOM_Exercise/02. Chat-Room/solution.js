function solve() {
   let sendButton = document.getElementById('send');
   let inputChat = document.getElementById('chat_input');
   let chatMessages = document.getElementById('chat_messages');
   sendButton.addEventListener('click', onClick)
   
   function onClick(){

      let message = document.createElement('div');
      let input = inputChat.value;

      message.className = 'message my-message';
      message.textContent = input;

      chatMessages.appendChild(message);

      document.getElementById('chat_input').value = "";
   }
}
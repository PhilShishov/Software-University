function softDo() {
    const textArea = document.getElementById('inputSection').getElementsByTagName('textarea')[0];
    const username = document.getElementById('inputSection').getElementsByTagName('input')[0];

    const sendBtn = document.getElementById('inputSection').getElementsByTagName('button')[0];

    sendBtn.addEventListener('click', sendToPending);

    function sendToPending() {
        const pendingQuestions = document.getElementById('pendingQuestions');

        if (textArea.value) {
            const divPendingQuestions = document.createElement('div');
            divPendingQuestions.className = 'pendingQuestion';            

            const img = document.createElement('img');
            img.src = './images/user.png';
            img.width = 32;
            img.height = 32;

            const span = document.createElement('span');

            if (username.value === '') {
                span.textContent = 'Anonymous';
            } else {
                span.textContent = username.value;
            }

            const p = document.createElement('p');
            p.textContent = textArea.value;

            const divActions = document.createElement('div');
            divActions.className = 'actions';

            const btnArchive = document.createElement('button');
            btnArchive.className = 'archive';
            btnArchive.textContent = 'Archive';
            btnArchive.addEventListener('click', () => {
                divPendingQuestions.remove();
            });

            const btnOpen = document.createElement('button');
            btnOpen.className = 'open';
            btnOpen.textContent = 'Open';
            btnOpen.addEventListener('click', () => {
                sendToOpen(span.textContent, p.textContent);
                divPendingQuestions.remove();
            });

            divActions.appendChild(btnArchive);
            divActions.appendChild(btnOpen);

            divPendingQuestions.appendChild(img);
            divPendingQuestions.appendChild(span);
            divPendingQuestions.appendChild(p);
            divPendingQuestions.appendChild(divActions);

            pendingQuestions.appendChild(divPendingQuestions);

            textArea.value = '';
            username.value = '';
        }

        function sendToOpen(name, question) {
            const openQuestions = document.getElementById('openQuestions');

            const divOpenQuestions = document.createElement('div');
            divOpenQuestions.className = 'openQuestion';
            
            const img = document.createElement('img');
            img.src = './images/user.png';
            img.width = 32;
            img.height = 32;

            const span = document.createElement('span');
            span.textContent = name;

            const p = document.createElement('p');
            p.textContent = question;

            const divActions = document.createElement('div');
            divActions.className = 'actions';

            const btnOpenReply = document.createElement('button');
            btnOpenReply.className = 'reply';
            btnOpenReply.textContent = 'Reply';
            btnOpenReply.addEventListener('click', () => {
                switch (btnOpenReply.textContent) {
                    case 'Reply':
                        divReplySection.style.display = 'block';
                        btnOpenReply.textContent = 'Back';
                        break;
                    case 'Back':
                        btnOpenReply.textContent = 'Reply';
                        divReplySection.style.display = 'none';
                        break;
                }
            });

            divActions.appendChild(btnOpenReply);

            const divReplySection = document.createElement('div');
            divReplySection.setAttribute('class', 'replySection');
            divReplySection.style.display = 'none';

            const replyInput = document.createElement('input');
            replyInput.setAttribute('class', 'replyInput');
            replyInput.type = 'text';
            replyInput.placeholder = 'Reply to this question here...';

            const btnReply = document.createElement('button');
            btnReply.setAttribute('class', 'replyButton');
            btnReply.textContent = 'Send';
            btnReply.addEventListener('click', sendReply);

            const olReply = document.createElement('ol');
            olReply.setAttribute('class', 'reply');
            olReply.setAttribute('type', '1');

            divReplySection.appendChild(replyInput);
            divReplySection.appendChild(btnReply);
            divReplySection.appendChild(olReply);

            divOpenQuestions.appendChild(img);
            divOpenQuestions.appendChild(span);
            divOpenQuestions.appendChild(p);
            divOpenQuestions.appendChild(divActions);
            divOpenQuestions.appendChild(divReplySection);

            openQuestions.appendChild(divOpenQuestions);

            function sendReply() {
                if (replyInput.value) {
                    const liReply = document.createElement('li');
                    liReply.textContent = replyInput.value;
                    olReply.appendChild(liReply);
                    replyInput.value = '';
                }
            }
        }
    }
}
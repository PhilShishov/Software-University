function solve() {
    const btnAddTask = document.getElementById('add');
    btnAddTask.addEventListener('click', addTask);

    function addTask(e) {
        e.preventDefault();
        const taskName = document.getElementsByTagName('input')[0].value;
        const description = document.getElementsByTagName('textarea')[0].value;
        const dueDate = document.getElementsByTagName('input')[1].value;

        let openSection = document.getElementsByTagName('section')[1].getElementsByTagName('div')[1];

        if (taskName && dueDate && description) {
            const article = createTask(taskName, description, dueDate, false, false);
            openSection.appendChild(article);
        }
    }

    function createTask(taskName, description, dueDate, isProgress, isComplete) {
        const article = document.createElement('article');

        const h3 = document.createElement('h3');
        h3.innerHTML = `${taskName}`;

        const p1 = document.createElement('p');
        p1.innerHTML = `Description: ${description}`;

        const p2 = document.createElement('p');
        p2.innerHTML = `Due Date: ${dueDate}`;

        article.appendChild(h3);
        article.appendChild(p1);
        article.appendChild(p2);

        if (!isProgress && !isComplete) {
            let progressSection = document.getElementsByTagName('section')[2].getElementsByTagName('div')[1];
            const div = document.createElement('div');
            div.classList.add('flex');

            const btnMove = document.createElement('button');
            btnMove.classList.add('green');
            btnMove.innerHTML = 'Start';

            btnMove.addEventListener('click', function (e) {
                e.preventDefault();
                const articleProgress = createTask(taskName, description, dueDate, true, false);
                progressSection.appendChild(articleProgress);
                // this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
            });

            const btnDelete = document.createElement('button');
            btnDelete.classList.add('red');
            btnDelete.innerHTML = 'Delete';

            btnDelete.addEventListener('click', function () {
                // e.preventDefault();

                this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
            });

            div.appendChild(btnMove);
            div.appendChild(btnDelete);

            article.appendChild(div);
        }

        if (isProgress && !isComplete) {
            let completeSection = document.getElementsByTagName('section')[3].getElementsByTagName('div')[1];
            const div = document.createElement('div');
            div.classList.add('flex');

            const btnDelete = document.createElement('button');
            btnDelete.classList.add('red');
            btnDelete.innerHTML = 'Delete';

            btnDelete.addEventListener('click', function () {
                // e.preventDefault();

                this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
            });

            const btnMove = document.createElement('button');
            btnMove.classList.add('orange');
            btnMove.innerHTML = 'Finish';

            btnMove.addEventListener('click', function () {
                // e.preventDefault();
                const articleFinish = createTask(taskName, description, dueDate, false, true);
                completeSection.appendChild(articleFinish);
                this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
            });

            div.appendChild(btnMove);
            div.appendChild(btnDelete);

            article.appendChild(div);
        }
        return article;
    }
}
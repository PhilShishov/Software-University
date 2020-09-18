function createArticle() {
	
	let title = document.getElementById('createTitle').value;
    let content = document.getElementById('createContent').value;
    const articleSection = document.getElementById('articles');

    if (title && content) {

        const article = document.createElement('article');

        const h3 = document.createElement('h3');
        h3.textContent = title;

        const p = document.createElement('p');
        p.textContent = content;

        article.appendChild(h3);
        article.appendChild(p);
        articleSection.appendChild(article);        
    }

    document.getElementById('createTitle').value = "";
    document.getElementById('createContent').value = "";
}
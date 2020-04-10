const homeController = function () {
    const getHome = async function (context) {
        // helper.addHeaderInfo(context);
        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await postModel.getAllPosts();
                let posts = await response.json();

                context.posts = [];
                context.myPosts = [];

                for (const post of posts) {
                    const isCreator = JSON.parse(storage.getData('userInfo')).username === post.creator;

                    if (isCreator) {
                        context.myPosts.push(post);
                    } else {
                        context.posts.push(post);
                    }
                }
            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: './views/common/header.hbs',
            postView: './views/post/postView.hbs',
            myPostView: './views/post/myPostView.hbs',
        }).then(function () {
            this.partial('./views/home/homePage.hbs')
        })
    };

    return {
        getHome
    }
}();
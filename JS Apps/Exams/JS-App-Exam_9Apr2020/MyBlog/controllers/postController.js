const postController = function () {

    const postCreatePost = function (context) {
        postModel.create(context.params)
            .then(helper.handler)
            .then(() => {
                // notify
                homeController.getHome(context);
            });
    }

    const getDetailsPost = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await postModel.getPost(context.params.postId);
                let post = await response.json();
                Object.keys(post).forEach((key) => {
                    context[key] = post[key];
                });

                // context.isCreator = JSON.parse(storage.getData('userInfo')).username === post.organizer;

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial('./views/post/details.hbs')
        });
    };

    const getEditPost = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await postModel.getPost(context.params.postId);
                let post = await response.json();

                Object.keys(post).forEach((key) => {
                    context[key] = post[key];
                });

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
        }).then(function () {
            this.partial('./views/post/edit.hbs')
        });
    };

    const postEditPost = function (context) {
        postModel.edit(context.params)
            .then(helper.handler)
            .then(() => {
                // notify
                homeController.getHome(context);
            });
    }

    const postDeletePost = function (context) {
        postModel.del(context.params.postId)
            .then(helper.handler)
            .then((data) => {
                // notify
                console.log(data);
                homeController.getHome(context);
            });
    }

    return {
        postCreatePost,
        getDetailsPost,
        getEditPost,
        postEditPost,
        postDeletePost,
    }
}();
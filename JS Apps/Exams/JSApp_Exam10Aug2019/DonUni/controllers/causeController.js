const causeController = function () {

    const getCreateCause = function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"

        }).then(function () {
            this.partial('./views/cause/create.hbs')
        });
    };

    const postCreateCause = function (context) {
        causeModel.create(context.params)
            .then(helper.handler)
            .then(() => {
                // notify
                homeController.getHome(context);
            });
    }

    const getAllCauses = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await causeModel.getAllCauses();
                context.causes = await response.json();
            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/cause/dashboard.hbs')
        });
    };

    const getDetailsCause = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            let response = await causeModel.getCause(context.params.causeId);
            let cause = await response.json();
            try {
                Object.keys(cause).forEach((key) => {
                    if (key === 'donors') {
                        cause[key] = cause[key].join(' ');
                    }
                    context[key] = cause[key];
                });

                context.isCreator = JSON.parse(storage.getData('userInfo'))._id === context._acl.creator;

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/cause/details.hbs')
        });
    };

    const postDetailsCause = function (context) {
        let causeDonation = Number(context.params.currentDonation);
        let causeId = context.params.causeId;
        causeModel.getCause(causeId)
            .then(helper.handler)
            .then((cause) => {
                console.log("Post Edit - " + cause);

                cause.collectedFunds += causeDonation;
                cause.donors.push(context.username);

                causeModel.donate(cause)
                    .then(helper.handler)
                    .then((cause) => {
                        console.log(cause);
                        context.redirect('#/dashboard')
                    })
            });
    }

    const getDeleteCause = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await causeModel.getCause(context.params.causeId);
                let cause = await response.json();

                Object.keys(cause).forEach((key) => {
                    if (key === 'donors') {
                        cause[key] = cause[key].join(' ');
                    }
                    context[key] = cause[key];
                });

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/cause/delete.hbs')
        });
    };

    const postDeleteCause = function (context) {
        causeModel.del(context.params.causeId)
            .then(helper.handler)
            .then((data) => {
                // notify
                console.log(data);
                homeController.getHome(context);
            });
    }

    return {
        getCreateCause,
        postCreateCause,
        getAllCauses,
        getDetailsCause,
        postDetailsCause,
        getDeleteCause,
        postDeleteCause,
    }
}();
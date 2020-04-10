const homeController = function () {
    const getHome = async function (context) {
        // helper.addHeaderInfo(context);

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await eventModel.getAllEvents();
                context.events = await response.json();
            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: './views/common/header.hbs',
            footer: './views/common/footer.hbs',
            eventView: './views/event/eventView.hbs'

        }).then(function () {
            this.partial('./views/home/homePage.hbs')
        })
    };

    return {
        getHome
    }
}();
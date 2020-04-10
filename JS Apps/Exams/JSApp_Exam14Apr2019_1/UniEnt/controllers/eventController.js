const eventController = function () {

    const getDetailsEvent = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await eventModel.getEvent(context.params.eventId);
                let event = await response.json();

                Object.keys(event).forEach((key) => {
                    context[key] = event[key];
                });

                context.isCreator = JSON.parse(storage.getData('userInfo')).username === event.organizer;

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/event/details.hbs')
        });
    };

    const getCreateEvent = function (context) {

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
            this.partial('./views/event/create.hbs')
        });
    };

    const postCreateEvent = function (context) {
        eventModel.create(context.params)
            .then(helper.handler)
            .then(() => {
                // notify
                homeController.getHome(context);
            });
    }

    const getEditEvent = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await eventModel.getEvent(context.params.eventId);
                let event = await response.json();

                Object.keys(event).forEach((key) => {
                    context[key] = event[key];
                });

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/event/edit.hbs')
        });
    };

    const postEditEvent = function (context) {
        eventModel.edit(context.params)
            .then(helper.handler)
            .then(() => {
                // notify
                homeController.getHome(context);
            });
    }

    const postDeleteEvent = function (context) {
        eventModel.deleteEvent(context.params.eventId)
            .then(helper.handler)
            .then((data) => {
                // notify
                console.log(data);
                homeController.getHome(context);
            });
    }

    const postJoinEvent = async function (context) {
        try {
            let response = await eventModel.getEvent(context.params.eventId);
            let event = await response.json();

            event.peopleInterestedIn++;

            eventModel.joinEvent(event)
                .then(helper.handler)
                .then(() => {
                    // notify
                    homeController.getHome(context);
                });

        } catch (error) {
            console.log(error);
        }
    }

    return {
        getDetailsEvent,
        getCreateEvent,
        postCreateEvent,
        getEditEvent,
        postEditEvent,
        postDeleteEvent,
        postJoinEvent
    }
}();
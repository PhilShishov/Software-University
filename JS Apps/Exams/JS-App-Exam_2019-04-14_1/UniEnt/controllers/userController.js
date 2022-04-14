const userController = function () {
  const getRegister = function (context) {
    context.loadPartials({
      header: "./views/common/header.hbs",
      footer: "./views/common/footer.hbs"

    }).then(function () {
      this.partial('./views/user/register.hbs')
    });
  };

  const postRegister = function (context) {
    userModel.register(context.params)
      .then(helper.handler)
      .then((data) => {
        storage.saveUser(data);
        homeController.getHome(context);
      });
  };

  const getLogin = function (context) {
    context.loadPartials({
      header: "./views/common/header.hbs",
      footer: "./views/common/footer.hbs"

    }).then(function () {
      this.partial('./views/user/login.hbs')
    });
  };

  const postLogin = function (context) {

    helper.notify('loading');
    userModel.login(context.params)
      .then(helper.handler)
      .then((data) => {
        helper.stopNotify();
        helper.notify('success', 'You just logged in');
        storage.saveUser(data);
        homeController.getHome(context);
      });
  };

  const logout = function (context) {
    userModel.logout()
      .then(helper.handler)
      .then(() => {
        storage.deleteUser();
        homeController.getHome(context);
      });
  };

  const getProfile = async function (context) {
    const loggedIn = storage.getData('userInfo') !== null;

    if (loggedIn) {
      const username = JSON.parse(storage.getData('userInfo')).username;
      context.loggedIn = loggedIn;
      context.username = username;
      try {
        let response = await eventModel.getAllEvents();
        let events = await response.json();
        context.events = [];

        for (const event of events) {
          let isCreator = JSON.parse(storage.getData('userInfo')).username === event.organizer;

          if (isCreator) {
            context.events.push(event);
            context.eventCount = context.events.length === 1 ?
              '1 event' :
              `${context.events.length} events`;

            context.name = event.name;
          }

          if (context.events.length === 0) {
            context.eventCount = '0 events';
          }
        }
      } catch (error) {
        console.log(error);
      }
    }

    context.loadPartials({
      header: './views/common/header.hbs',
      footer: './views/common/footer.hbs'

    }).then(function () {
      this.partial('./views/user/userPage.hbs')
    });
  };

  return {
    getRegister,
    postRegister,
    getLogin,
    postLogin,
    logout,
    getProfile
  }
}();
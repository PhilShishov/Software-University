const userController = function () {
  const getRegister = function (context) {
    context.loadPartials({
      header: "./views/common/header.hbs"
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

    }).then(function () {
      this.partial('./views/user/login.hbs')
    });
  };

  const postLogin = function (context) {
    // helper.notify('loading');
    userModel.login(context.params)
      .then(helper.handler)
      .then((data) => {
        // helper.stopNotify();
        // helper.notify('success', 'You just logged in');
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

  return {
    getRegister,
    postRegister,
    getLogin,
    postLogin,
    logout,
  }
}();
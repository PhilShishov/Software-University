const app = Sammy('body', function () {
  this.use('Handlebars', 'hbs');

  // Home
  this.get('#/home', homeController.getHome);

  // User
  this.get('#/register', userController.getRegister);
  this.post('#/register', userController.postRegister);

  this.get('#/login', userController.getLogin);
  this.post('#/login', userController.postLogin);

  this.get('#/logout', userController.logout);
  this.get('#/profile', userController.getProfile);

  // Event
  this.get('#/details/:eventId', eventController.getDetailsEvent);

  this.get('#/create', eventController.getCreateEvent);
  this.post('#/create', eventController.postCreateEvent);

  this.get('#/edit/:eventId', eventController.getEditEvent);
  this.post('#/edit/:eventId', eventController.postEditEvent);

  this.get('#/delete/:eventId', eventController.postDeleteEvent);

  this.get('#/join/:eventId', eventController.postJoinEvent);
});

(() => {
  app.run('#/home');
})();
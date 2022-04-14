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

  // Cause
  this.get('#/create', causeController.getCreateCause);
  this.post('#/create', causeController.postCreateCause);

  this.get('#/dashboard', causeController.getAllCauses);

  this.get('#/cause/details/:causeId', causeController.getDetailsCause);
  this.post('#/cause/details/:causeId', causeController.postDetailsCause);

  this.get('#/delete/:causeId', causeController.getDeleteCause);
  this.post('#/delete/:causeId', causeController.postDeleteCause);
});

(() => {
  app.run('#/home');
})();
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

  // Movie
  this.get('#/myMovies', movieController.loadMyMovies);
  this.get('#/cinema', movieController.loadCinema);
  this.get('#/details/:movieId', movieController.getDetailsMovie);

  this.get('#/create', movieController.getCreateMovie);
  this.post('#/create', movieController.postCreateMovie);

  this.get('#/edit/:movieId', movieController.getEditMovie);
  this.post('#/edit/:movieId', movieController.postEditMovie);

  this.get('#/delete/:movieId', movieController.getDeleteMovie);
  this.post('#/delete/:movieId', movieController.postDeleteMovie);

  this.get('#/buy/:movieId', movieController.postBuyTicket);
});

(() => {
  app.run('#/home');
})();
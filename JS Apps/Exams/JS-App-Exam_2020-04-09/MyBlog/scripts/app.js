window.onload = () => {
  Sammy("body", function () {

    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome);

    // User
    this.get('#/register', userController.getRegister);
    this.get('#/login', userController.getLogin);

    this.post('#/register', userController.postRegister);
    this.post('#/login', userController.postLogin);
    this.get('#/logout', userController.logout);

    // Post
    this.post('#/create', postController.postCreatePost);
    this.get('#/details/:postId', postController.getDetailsPost);

    this.get('#/edit/:postId', postController.getEditPost);
    this.post('#/edit/:postId', postController.postEditPost);

    this.get('#/delete/:postId', postController.postDeletePost);
  }).run('#/home');
}
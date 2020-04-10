const movieController = function () {

    const loadCinema = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await movieModel.getAllMovies();
                context.movies = await response.json();
               
            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs",
        }).then(function () {
            this.partial('./views/movie/cinema.hbs')
        });
    };

    const loadMyMovies = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;

            const userId = JSON.parse(storage.getData('userInfo'))._id;
            try {
                // let response = await movieModel.getAllMovies();
                let response = await movieModel.getMyMovies(userId);
                context.movies = await response.json();
                // context.movies = [];

                // for (const movie of movies) {
                //     let isCreator = JSON.parse(storage.getData('userInfo')).username === movie.creator;

                //     if (isCreator) {
                //         context.movies.push(movie);
                //     }
                // }
            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs",
            movieView: './views/movie/movieView.hbs'
        }).then(function () {
            this.partial('./views/movie/myMovies.hbs')
        });
    };

    const getCreateMovie = function (context) {

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
            this.partial('./views/movie/create.hbs')
        });
    };

    const postCreateMovie = function (context) {
        movieModel.create(context.params)
            .then(helper.handler)
            .then(() => {
                // notify
                homeController.getHome(context);
            });
    }

    const getDetailsMovie = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await movieModel.getMovie(context.params.movieId);
                let movie = await response.json();

                Object.keys(movie).forEach((key) => {
                    context[key] = movie[key];
                });
            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/movie/details.hbs')
        });
    };

    const getEditMovie = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await movieModel.getMovie(context.params.movieId);
                let movie = await response.json();

                Object.keys(movie).forEach((key) => {
                    context[key] = movie[key];
                });

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/movie/edit.hbs')
        });
    };

    const postEditMovie = function (context) {
        debugger;
        movieModel.edit(context.params)
            .then(helper.handler)
            .then(() => {
                // notify
                homeController.getHome(context);
            });
    }

    const getDeleteMovie = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            try {
                let response = await movieModel.getMovie(context.params.movieId);
                let movie = await response.json();

                Object.keys(movie).forEach((key) => {
                    context[key] = movie[key];
                });

            } catch (error) {
                console.log(error);
            }
        }

        context.loadPartials({
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        }).then(function () {
            this.partial('./views/movie/delete.hbs')
        });
    };

    const postDeleteMovie = function (context) {
        movieModel.deleteMovie(context.params.movieId)
            .then(helper.handler)
            .then((data) => {
                // notify
                console.log(data);
                homeController.getHome(context);
            });
    }

    const postBuyTicket = async function (context) {
        try {
            let response = await movieModel.getMovie(context.params.movieId);
            let movie = await response.json();

            movie.tickets--;

            movieModel.buyTicket(movie)
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
        loadCinema,
        loadMyMovies,
        getDetailsMovie,
        getCreateMovie,
        postCreateMovie,
        getEditMovie,
        postEditMovie,
        getDeleteMovie,
        postDeleteMovie,
        postBuyTicket
    }
}();
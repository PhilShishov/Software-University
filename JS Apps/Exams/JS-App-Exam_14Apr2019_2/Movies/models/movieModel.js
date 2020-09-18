const movieModel = function () {
    const getMovie = function (id) {
        let url = `/appdata/${storage.appKey}/movies/${id}`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const getAllMovies = function () {
        let sortCriteria = JSON.stringify({
            'tickets': -1
        });

        let url = `/appdata/${storage.appKey}/movies?query={}&sort=${sortCriteria}`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const getMyMovies = function (userId) {
        let sortCriteria = JSON.stringify({
            'tickets': -1
        });
        let url = `/appdata/${storage.appKey}/movies?query={"_acl.creator":"${userId}"}&sort=${sortCriteria}`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const create = function (params) {
        let data = {
            ...params,
            creator: JSON.parse(storage.getData('userInfo')).username,
        };

        let url = `/appdata/${storage.appKey}/movies`;

        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.post(url, headers);
    }

    const edit = function (params) {
        let url = `/appdata/${storage.appKey}/movies/${params.movieId}`;

        delete params.movieId;

        let data = {
            ...params,
            creator: JSON.parse(storage.getData('userInfo')).username,
        };

        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.put(url, headers);
    }

    const deleteMovie = function (id) {
        let url = `/appdata/${storage.appKey}/movies/${id}`;

        let headers = {
            headers: {}
        };

        return requester.del(url, headers);
    }

    const buyTicket = function (movie) {
        let url = `/appdata/${storage.appKey}/movies/${movie._id}`;

        delete movie._id;

        let headers = {
            body: JSON.stringify({ ...movie }),
            headers: {}
        };

        return requester.put(url, headers);
    }

    return {
        getAllMovies,
        getMyMovies,
        getMovie,
        create,
        edit,
        deleteMovie,
        buyTicket
    }
}();
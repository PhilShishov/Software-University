const causeModel = function () {

    const getAllCauses = function () {
        let url = `/appdata/${storage.appKey}/causes`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const getCause = function (id) {
        let url = `/appdata/${storage.appKey}/causes/${id}`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const create = function (params) {
        let data = {
            ...params,
            donors: [],
            collectedFunds: 0
        };

        let url = `/appdata/${storage.appKey}/causes`;

        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.post(url, headers);
    }

    const del = function (id) {
        let url = `/appdata/${storage.appKey}/causes/${id}`;

        let headers = {
            headers: {}
        };

        return requester.del(url, headers);
    }

    const donate = function (cause) {
        let url = `/appdata/${storage.appKey}/causes/${cause._id}`;

        delete cause._id;

        let headers = {
            body: JSON.stringify({ ...cause }),
            headers: {}
        };

        return requester.put(url, headers);
    }

    return {
        getAllCauses,
        getCause,
        create,
        del,
        donate
    }
}();
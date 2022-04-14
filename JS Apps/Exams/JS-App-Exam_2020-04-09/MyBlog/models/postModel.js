const postModel = function () {

    const getAllPosts = function () {
        let url = `/appdata/${storage.appKey}/posts`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const getPost = function (id) {
        let url = `/appdata/${storage.appKey}/posts/${id}`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const create = function (params) {
        let data = {
            ...params,
            creator: JSON.parse(storage.getData('userInfo')).username
        };

        let url = `/appdata/${storage.appKey}/posts`;

        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.post(url, headers);
    }

    const edit = function (params) {
        let url = `/appdata/${storage.appKey}/posts/${params.postId}`;

        delete params.postId;

        let headers = {
            body: JSON.stringify({ ...params }),
            headers: {}
        };

        return requester.put(url, headers);
    }

    const del = function (id) {
        let url = `/appdata/${storage.appKey}/posts/${id}`;

        let headers = {
            headers: {}
        };

        return requester.del(url, headers);
    }

    return {
        getAllPosts,
        getPost,
        create,
        edit,
        del,
    }
}();
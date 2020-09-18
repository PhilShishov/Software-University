const eventModel = function () {

    const getAllEvents = function () {
        let url = `/appdata/${storage.appKey}/events`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const getEvent = function (id) {
        let url = `/appdata/${storage.appKey}/events/${id}`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    }

    const create = function (params) {
        let data = {
            ...params,
            peopleInterestedIn: 0,
            organizer: JSON.parse(storage.getData('userInfo')).username
        };

        let url = `/appdata/${storage.appKey}/events`;

        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.post(url, headers);
    }

    const edit = function (params) {
        let url = `/appdata/${storage.appKey}/events/${params.eventId}`;

        delete params.eventId;

        let headers = {
            body: JSON.stringify({ ...params }),
            headers: {}
        };

        return requester.put(url, headers);
    }

    const deleteEvent = function (id) {
        let url = `/appdata/${storage.appKey}/events/${id}`;

        let headers = {
            headers: {}
        };

        return requester.del(url, headers);
    }

    const joinEvent = function (event) {
        let url = `/appdata/${storage.appKey}/events/${event._id}`;

        delete event._id;

        let headers = {
            body: JSON.stringify({ ...event }),
            headers: {}
        };

        return requester.put(url, headers);
    }

    return {
        getAllEvents,
        getEvent,
        create,
        edit,
        deleteEvent,
        joinEvent
    }
}();
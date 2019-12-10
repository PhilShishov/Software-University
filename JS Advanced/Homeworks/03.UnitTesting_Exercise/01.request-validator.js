function validateRequest(request) {
    const validMethod =
        request.method === 'GET' ||
        request.method === 'POST' ||
        request.method === 'DELETE' ||
        request.method === 'CONNECT';

    let validURI = false;

    if (request.hasOwnProperty('uri')) {
        if (request.uri.match(/^\*$|^([a-z\d\.]+)$/g)) {
            validURI = true;
        }
    }

    const validVersion =
        request.version === 'HTTP/0.9' ||
        request.version === 'HTTP/1.0' ||
        request.version === 'HTTP/1.1' ||
        request.version === 'HTTP/2.0';

    let validMessage = false;

    if (request.hasOwnProperty('message')) {
        const pattern = /[<>\\&'"]/g;
        validMessage = !pattern.test(request.message);
    }

    if (!validMethod) {
        throw new Error('Invalid request header: Invalid Method');
    } else if (!validURI) {
        throw new Error('Invalid request header: Invalid URI');
    } else if (!validVersion) {
        throw new Error('Invalid request header: Invalid Version');
    } else if (!validMessage) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return console.log(request);
}

validateRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
});

validateRequest({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
});

validateRequest({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
});
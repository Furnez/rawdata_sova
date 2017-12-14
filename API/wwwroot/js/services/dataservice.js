define(['jquery', 'knockout'], function ($, ko) {
    const { protocol, hostname, port } = document.location;
    var url = `${protocol}//${hostname}:${port}`

    var getPosts = (callback) => {

        url += "/api/posts";
        $.getJSON(url, callback);
    };

    var getPost = function (id, callback) {
        url += "/api/posts/" + id;
        $.getJSON(url, callback);
    };

    return {
        getPosts,
        getPost
    };
});
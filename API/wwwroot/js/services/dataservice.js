define(['jquery', 'knockout'], function ($, ko) {
    const { protocol, hostname, port } = document.location;
    const base = `${protocol}//${hostname}:${port}`

    var getPosts = (callback) => {
        let url = base + "/api/posts";

        $.getJSON(url, callback);
    };

    var getPost = function (id, callback) {
        let url = base + "/api/posts/" + id;

        $.getJSON(url, callback);
    };

    var getResult = (search, callback) => {
        let searchstr = search.replace(/\s/g, "%20");
        let url = base + "/api/posts/search/" + searchstr;

        $.getJSON(url,callback);
    };


    return {
        getPosts,
        getPost,
        getResult
        };
});
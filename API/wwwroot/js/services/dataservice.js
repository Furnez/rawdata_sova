define(['jquery', 'knockout'], function ($, ko) {
    const { protocol, hostname, port } = document.location;
    var url = `${protocol}//${hostname}:${port}`

    var getPosts = (callback) => {

        url += "/api/posts";
        console.log("called");
        console.log(url);
        console.log($.getJSON(url, callback));
    };

    var getPost = function (id, callback) {
        url += "/api/posts/" + id;
        console.log("called");
        console.log(url);
        var test = $.getJSON(url, callback);
        console.log(test);
        return test;

    };

    var getResult = function (search, callback) {
        url += "/api/posts/search/" + search;
        $.getJSON(url,callback);
    };

    return {
        getPosts,
        getPost
    };
});
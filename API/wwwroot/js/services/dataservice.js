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
        var test = $.getJSON(url, callback);
        return test;

    };

    var getResult = (search, callback) => {
        url += "/api/posts/search/" + search;
        console.log(url);
        var test = $.getJSON(url,callback);
        console.log(test);
        return test;
    };

    return {
        getPosts,
        getPost,
        getResult
    };
});
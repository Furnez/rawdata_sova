define(['jquery', 'knockout'], function ($, ko) {
    const { protocol, hostname, port } = document.location;
    const base = `${protocol}//${hostname}:${port}`

    var getPosts = (callback) => {

        let url = base + "/api/posts";
        console.log("called");
        console.log(url);
        console.log($.getJSON(url, callback));
    };

    var getPost = function (id, callback) {
        let url = base + "/api/posts/" + id;
        var test = $.getJSON(url, callback);
        return test;

    };

    var getResult = (search, callback) => {
        let searchstr = search.replace(/\s/g, "%20");
        let url = base + "/api/posts/search/" + searchstr;
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
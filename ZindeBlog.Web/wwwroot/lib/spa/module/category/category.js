"use strict";
var Topic = (function () {
    function Topic() {
    }
    return Topic;
}());
exports.Topic = Topic;
var TopicStatus;
(function (TopicStatus) {
    TopicStatus[TopicStatus["Draft"] = 0] = "Draft";
    TopicStatus[TopicStatus["Published"] = 1] = "Published";
    TopicStatus[TopicStatus["Trash"] = 255] = "Trash";
})(TopicStatus = exports.TopicStatus || (exports.TopicStatus = {}));

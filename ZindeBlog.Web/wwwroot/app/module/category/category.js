"use strict";
var Topic = (function () {
    function Topic() {
    }
    return Topic;
}());
exports.Topic = Topic;
(function (TopicStatus) {
    TopicStatus[TopicStatus["Draft"] = 0] = "Draft";
    TopicStatus[TopicStatus["Published"] = 1] = "Published";
    TopicStatus[TopicStatus["Trash"] = 255] = "Trash";
})(exports.TopicStatus || (exports.TopicStatus = {}));
var TopicStatus = exports.TopicStatus;
//# sourceMappingURL=category.js.map
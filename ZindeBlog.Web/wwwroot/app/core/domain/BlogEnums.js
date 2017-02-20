"use strict";
(function (CommentStatus) {
    CommentStatus[CommentStatus["Pending"] = 0] = "Pending";
    CommentStatus[CommentStatus["Approved"] = 1] = "Approved";
    CommentStatus[CommentStatus["Reject"] = 2] = "Reject";
    CommentStatus[CommentStatus["Junk"] = 255] = "Junk";
})(exports.CommentStatus || (exports.CommentStatus = {}));
var CommentStatus = exports.CommentStatus;
(function (PageStatus) {
    PageStatus[PageStatus["Draft"] = 0] = "Draft";
    PageStatus[PageStatus["Published"] = 1] = "Published";
})(exports.PageStatus || (exports.PageStatus = {}));
var PageStatus = exports.PageStatus;
(function (TopicStatus) {
    TopicStatus[TopicStatus["Draft"] = 0] = "Draft";
    TopicStatus[TopicStatus["Published"] = 1] = "Published";
    TopicStatus[TopicStatus["Trash"] = 255] = "Trash";
})(exports.TopicStatus || (exports.TopicStatus = {}));
var TopicStatus = exports.TopicStatus;
(function (WidgetType) {
    WidgetType[WidgetType["Administration"] = 1] = "Administration";
    WidgetType[WidgetType["Category"] = 2] = "Category";
    WidgetType[WidgetType["Tag"] = 3] = "Tag";
    WidgetType[WidgetType["RecentTopic"] = 4] = "RecentTopic";
    WidgetType[WidgetType["RecentComment"] = 5] = "RecentComment";
    WidgetType[WidgetType["MonthStatistics"] = 6] = "MonthStatistics";
    WidgetType[WidgetType["Page"] = 7] = "Page";
    WidgetType[WidgetType["Search"] = 8] = "Search";
    WidgetType[WidgetType["Link"] = 9] = "Link";
})(exports.WidgetType || (exports.WidgetType = {}));
var WidgetType = exports.WidgetType;
//# sourceMappingURL=BlogEnums.js.map
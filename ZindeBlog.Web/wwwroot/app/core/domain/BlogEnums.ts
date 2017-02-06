export enum CommentStatus {
    Pending = 0,

    Approved = 1,

    Reject = 2,

    Junk = 255
}
export enum PageStatus {
    Draft = 0,

    Published = 1
}
export enum TopicStatus {
    Draft = 0,

    Published = 1,

    Trash = 255
}
export enum WidgetType {
    Administration = 1,

    Category = 2,

    Tag = 3,

    RecentTopic = 4,

    RecentComment = 5,

    MonthStatistics = 6,

    Page = 7,

    Search = 8,

    Link = 9
}
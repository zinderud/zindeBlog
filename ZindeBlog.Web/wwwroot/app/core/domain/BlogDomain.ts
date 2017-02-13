
import {CommentStatus,PageStatus,TopicStatus,WidgetType } from "./BlogEnums"
export interface Category {
    ID: number;
    Name: string;
    Description: string;
    Topic: Topic;
}
export class CategoryTopic {
    CategoryID: number;
    TopicID: number;
    Category: Category;
    Topic: Topic;
}
export class Comment {
    ID: number;
    TopicID: number;
    ReplyToID: number;
    Status: CommentStatus;
    Email: string;
    Name: string;
    WebSite: string;
    Content: string;
    CreateDate: Date;
    CreateIP: string;
    NotifyOnComment: boolean;
    UserID: number;
}
export class Link {
    ID: number;
    Title: string;
    Url: string;
    Sort: number;
    OpenInNewWindow: string;
}
export class Page {
    ID: number;
    ParentID: number;
    Title: string;
    Content: string;
    Alias: string;
    Keywords: string;
    Description: string;
    CreateDate: Date;
    EditDate: Date;
    IsHomePage: boolean;
    ShowInList: boolean;
    Order: number;
    Status: PageStatus;
}
export class Setting {
    Key: string;
    Value: string;
}
export class Tag {
    ID: number;
    Keyword: string;
}
export class TagTopic {
    TagID: number;
    TopicID: number;
    Tag: Tag;
    Topic: Topic;
}
export class Topic {
    ID: number;
    Title: string;
    Content: string;
    Alias: string;
    Summary: string;
    AllowComment: boolean;
    Status: TopicStatus;
    CreateUserID: number;
    CreateDate: Date;
    EditUserID: number;
    EditDate: Date;
}
export class UserToken {
    Token: string;
    UserID: number;
}
export class Widget {
    ID: number;
    Type: WidgetType;
    Config: string;
}
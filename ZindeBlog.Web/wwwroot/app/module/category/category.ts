export interface ICategory {
    ID: number;
    Name: string;
    Description: string;
   topic:Topic
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
export enum TopicStatus {
    Draft = 0,

    Published = 1,

    Trash = 255
}
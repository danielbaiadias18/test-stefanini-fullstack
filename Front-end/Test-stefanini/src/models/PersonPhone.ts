import { iPerson } from "./Person";

export interface iPersonPhone{
    businessEntityID: number;
    phoneNumber: string;
    phoneNumberTypeID: number;
    name: string;
    person: iPerson;
}
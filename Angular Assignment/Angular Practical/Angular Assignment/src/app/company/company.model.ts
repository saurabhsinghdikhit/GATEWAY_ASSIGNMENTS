import { Branch } from "./branch.model";

export class Company {
    id:number;
    name:string;
    email:string;
    totalEmployee:number;
    address:string;
    isCompanyActive:boolean;
    totalBranch:number;
    companyBranch:Branch[];
}

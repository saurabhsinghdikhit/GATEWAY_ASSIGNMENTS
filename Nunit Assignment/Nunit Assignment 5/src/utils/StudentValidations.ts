export class StudentValidations{
    isEmailValid(email): boolean {
        const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return regularExpression.test(String(email).toLowerCase());
    }
    isPhoneValid(phone): boolean {
        const regularExpression = /[0-9\+\-\ ]/;
        return regularExpression.test(String(phone).toLowerCase());
    }
    isNameValid(name:string):boolean{
        return name.length>2?true:false;
    }
    isGenderValid(gender:string):boolean{
        if(gender=="male" || gender=="female"|| gender=="other")
            return true;
        else
            return false;
    }
    isMarksValid(marks:number):boolean{
        return marks>=0 && marks <=100 ? true: false;
    }
}
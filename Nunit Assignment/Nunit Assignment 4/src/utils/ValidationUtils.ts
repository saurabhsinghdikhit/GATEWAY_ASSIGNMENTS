export class ValidationUtils{
    isEmailValid(email): boolean {
        const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return regularExpression.test(String(email).toLowerCase());
    }
    isPhoneValid(phone): boolean {
        const regularExpression = /[0-9\+\-\ ]/;
        return regularExpression.test(String(phone).toLowerCase());
    }
    isObject(val) {
        if (val === null) { 
            return false; 
        }
        return ((typeof val === 'function') || (typeof val === 'object'));
    }
    isNotNullAndNotEmpty(data) {
        if (data !== null && data !== '') {
            return true;
        }
        return false;
    }
    isUndefined(data) {

        if (data === "undefined") {
            return true;
        }
        return false;
    }
}
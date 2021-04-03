export class MockCharacterUtils {

    // returns lower case
    public lowerCase(str) {
        return str.toLowerCase();
    }

    // returns uppercase case
    public upperCase(str) {
        return str.toUpperCase();
    }

    // returns propercase case
    public properCase(str) {
        return this.lowerCase(str).replace(/^\w|\s\w/g, this.upperCase);
    }

    // returns sentence case
    public sentenceCase(str) {
        return this.lowerCase(str).replace(/(^\w)|\.\s+(\w)/gm, this.upperCase);
    }

    // returns removed last character string
    public  removeLastCharacter(str) {
        return str.slice(0, -1) ;
    }
}

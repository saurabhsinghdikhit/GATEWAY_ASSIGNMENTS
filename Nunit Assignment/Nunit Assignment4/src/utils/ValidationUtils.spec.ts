import { ValidationUtils } from "./ValidationUtils";

describe('Utility Testing : Validation ', () => {

    // Using mocking with spy
    let validationUtils : ValidationUtils;
    let spy: any;

    beforeEach(() => {
        validationUtils=new ValidationUtils();
    });
    afterEach(()=>{
        validationUtils=null;
    });

    it('is my email is valid',()=>{

        // Arrange
        let inputString="saurabh@gmail.com";

        // Act
        spy = spyOn(validationUtils, 'isEmailValid').and.returnValue(true);
        let result=validationUtils.isEmailValid(inputString);

        // Assert
        expect(result).toBeTrue();
    });

    it('is my phone is valid',()=>{
        
        // Arrange
        let inputString="21221615";

        // Act
        spy = spyOn(validationUtils, 'isPhoneValid').and.returnValue(false);
        let result=validationUtils.isPhoneValid(inputString);

        // Assert
        expect(result).toBeFalse();
    });

    it('is this variable object',()=>{
        
        // Arrange
        let inputString;

        // Act
        spy = spyOn(validationUtils, 'isObject').and.returnValue(true);
        let result=validationUtils.isObject(inputString);

        // Assert
        expect(result).toBeTrue();
    });

    it('is this object null or empty',()=>{
        
        // Arrange
        let inputString;

        // Act
        spy = spyOn(validationUtils, 'isNotNullAndNotEmpty').and.returnValue(true);
        let result=validationUtils.isNotNullAndNotEmpty(inputString);

        // Assert
        expect(result).toBeTrue();
    });

    it('is this object Undefined',()=>{
        
        // Arrange
        let inputString;

        // Act
        spy = spyOn(validationUtils, 'isUndefined').and.returnValue(false);
        let result=validationUtils.isUndefined(inputString);

        // Assert
        expect(result).toBeFalse();
    });
   
});


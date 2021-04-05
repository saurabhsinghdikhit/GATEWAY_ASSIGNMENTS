import { MockStudentValidations } from "./MockStudentValidations";

describe('Utility Testing : User Validation ', () => {

    // Using mock instance of util class
    let mockStudentValidations : MockStudentValidations;

    beforeEach(() => {
        mockStudentValidations=new MockStudentValidations();
    });
    afterEach(()=>{
        mockStudentValidations=null;
    });

    it('is my email valid',()=>{

        // Arrange
        let inputString="saurabh@gmail.com";

        // Act
        let result=mockStudentValidations.isEmailValid(inputString);

        // Assert
        expect(result).toBeTrue();
    });

    it('is my phone valid',()=>{

        // Arrange
        let inputString="9621221615";

        // Act
        let result=mockStudentValidations.isPhoneValid(inputString);

        // Assert
        expect(result).toBeTrue();
    });

    it('is my name valid',()=>{

        // Arrange
        let inputString="ram";

        // Act
        let result=mockStudentValidations.isNameValid(inputString);

        // Assert
        expect(result).toBeTrue();
    });

    it('is my gender valid',()=>{

        // Arrange
        let inputString="male";

        // Act
        let result=mockStudentValidations.isGenderValid(inputString);

        // Assert
        expect(result).toBeTrue();
    });

    it('is my gender valid',()=>{

        // Arrange
        let inputMarks=45;

        // Act
        let result=mockStudentValidations.isMarksValid(inputMarks);

        // Assert
        expect(result).toBeTrue();
    });
});
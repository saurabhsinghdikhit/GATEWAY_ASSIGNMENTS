import { CharacterUtils } from "./characterUtils";
import { MockCharacterUtils } from "./MockCharacterUtils";

describe('Utility Testing : Character ', () => {

    // Using original instance of util class
    let characterUtils : CharacterUtils;

    // Using mock instance of util class
    let mockCharacterUtils : MockCharacterUtils;

    beforeEach(() => {
        characterUtils=new CharacterUtils();
        mockCharacterUtils=new MockCharacterUtils();
    });
    afterEach(()=>{
        characterUtils=null;
        mockCharacterUtils=null;
    });

    it('is my string in lower case',()=>{

        // Arrange
        let inputString="ABC";

        // Act
        let result=characterUtils.lowerCase(inputString);

        // Assert
        expect(result).toEqual("abc");
    });

    it('is my string in upper case',()=>{

        // Arrange
        let inputString="abc";

        // Act
        let result=characterUtils.upperCase(inputString);

        // Assert
        expect(result).toEqual("ABC");
    });

    it('is my string in propercase case',()=>{

        // Arrange
        let inputString="saurabh singh";

        // Act
        let result=mockCharacterUtils.properCase(inputString);

        // Assert
        expect(result).toEqual("Saurabh Singh");
    });

    it('is my sentence in sentence case',()=>{

        // Arrange
        let inputString="saurabh singh dikhit.he is very good boy.";

        // Act
        let result=mockCharacterUtils.sentenceCase(inputString);

        // Assert
        expect(result).toEqual("Saurabh singh dikhit.he is very good boy.");
    });

    it('remove last character of my string',()=>{

        // Arrange
        let inputString="Saurabh";

        // Act
        let result=mockCharacterUtils.removeLastCharacter(inputString);

        // Assert
        expect(result).toEqual("Saurab");
    });


   
});


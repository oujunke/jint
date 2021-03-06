/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-314-1.js
 * @description Object.defineProperty - 'O' is an Arguments object of a function that has formal parameters, 'P' is property, and 'desc' is accessor descriptor, test 'P' is defined in 'O' with all correct attribute values (10.6 [[DefineOwnProperty]] step 3)
 */


function testcase() {
        return (function (a, b, c) {
            function getFunc() {
                return "getFunctionString";
            }
            function setFunc(value) {
                this.testgetFunction = value;
            }
            Object.defineProperty(arguments, "genericProperty", {
                get: getFunc,
                set: setFunc,
                enumerable: true,
                configurable: true
            });
            return accessorPropertyAttributesAreCorrect(arguments, "genericProperty", getFunc, setFunc, "testgetFunction", true, true);
            }(1, 2, 3));
    }
runTestCase(testcase);

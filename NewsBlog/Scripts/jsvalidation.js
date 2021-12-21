let wrongColor = "pink";
let defaultColor = "white";
let checkName = /^[A-Z]{1}[a-z]+$/;
let checkText = /^.+$/

function TagsCheck(tagsForm) {
    var tagsInputter = tagsForm.tags;
    var tags = tagsInputter.value;
    if (tags == undefined || tags == null || tags == "") {
        tagsInputter.style.backgroundColor = wrongColor;
        return false;
    }
    else tagsInputter.style.backgroundColor = defaultColor;

    return true;
}

function QuestionnaireCheck(resultForm) {
    var firstNameInputter = resultForm.firstName;
    var firstName = firstNameInputter.value;

    if (!checkName.test(firstName)) {
        firstNameInputter.style.backgroundColor = wrongColor;
        return false;
    }
    else firstNameInputter.style.backgroundColor = defaultColor;

    var lastNameInputter = resultForm.lastName;
    var lastName = lastNameInputter.value;

    if (!checkName.test(lastName)) {
        lastNameInputter.style.backgroundColor = wrongColor;
        return false;
    }
    else lastNameInputter.style.backgroundColor = defaultColor;

    return true;
}

function FeedbackCheck(feedbackForm) {
    var nameInputter = feedbackForm.authorName;
    var name = nameInputter.value;

    if (!checkName.test(name)) {
        nameInputter.style.backgroundColor = wrongColor;
        return false;
    }
    else nameInputter.style.backgroundColor = defaultColor;

    var reviewInputter = feedbackForm.reviewText;
    var text = reviewInputter.value;

    if (!checkText.test(text)) {
        reviewInputter.style.backgroundColor = wrongColor;
        return false;
    }
    else reviewInputter.style.backgroundColor = defaultColor;

    return true;
}
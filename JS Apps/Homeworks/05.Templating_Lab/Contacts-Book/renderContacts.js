function showDetails(id){
    $(`#${id}`).toggle();
}
$(() => {
    Promise.all([$.get("./templates/contacts-info.hbs"), $.get("./templates/partials/contact-details.hbs")])
    .then(([contactsInfoHTML, contactsDetailsHTML]) => {
        Handlebars.registerPartial("contactDetails", contactsDetailsHTML);
        let template = Handlebars.compile(contactsInfoHTML);
        let context = {
            contacts
        }
        let renderedHTML = template(context);
        $('body').append(renderedHTML);
    })
    .catch((error) => {
        console.log(error);
    })
})
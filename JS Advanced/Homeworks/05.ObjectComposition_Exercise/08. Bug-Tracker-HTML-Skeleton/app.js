function bugReportModule() {
    let id = 0;
    let container;
    let sortingContainer = [];
    
    return {
        report: function (author, description, reproducible, severity) {
            const newReport = $('<div>')
                .addClass('report')
                .attr('id', `report_${id}`);

            const body = $('<div>')
                .addClass('body')
                .append($('<p>').text(`${description}`));

            const title = $('<div>')
                .addClass('title')
                .append($('<span>').addClass('author').text(`${author}`))
                .append($('<span>').addClass('status').text(`Open | ${severity}`));

            newReport.append(body);
            newReport.append(title);
            container.append(newReport);

            sortingContainer[id] = {
                id: id,
                author: author,
                description: description,
                reproducible: reproducible,
                severity: severity,
                status: 'Open'
            };

            id++;
        },
        setStatus: function (id, newStatus) {
            sortingContainer[id].status = newStatus;
            const statusRef = $(`#report_${id}`).find('.status');
            const oldText = statusRef.text();
            const args = oldText.split(' | ');
            const newText = `${newStatus}` + ' | ' + args[1];
            statusRef.text(newText);
        },
        remove: function (id) {
            sortingContainer = sortingContainer
                .filter(e => e.id !== id);
            $(`#report_${id}`).remove();
        },
        sort: function (method) {
            switch (method) {
                case 'author': return sortByAuthor();
                case 'severity': return sortBySeverity();
                case 'ID': return sortById();
            }
        },
        output: function (selector) {
            container = $(selector);
        }
    };

    function sortByAuthor() {
        container.html('');
        sortingContainer = sortingContainer
            .sort((a,b) => a.author.localeCompare(b.author));
        container.html(reconstructContainer(sortingContainer));
    }

    function sortBySeverity() {
        container.html('');
        sortingContainer = sortingContainer
            .sort((a,b) => a.severity - b.severity);
        container.html(reconstructContainer(sortingContainer));
    }

    function sortById() {
        container.html('');
        sortingContainer = sortingContainer
            .sort((a,b) => a.id - b.id);
        container.html(reconstructContainer(sortingContainer));
    }

    function reconstructContainer(sorted) {
        for (let bug of sorted) {
            const newReport = $('<div>')
                .addClass('report')
                .attr('id', `report_${bug.id}`);

            const body = $('<div>')
                .addClass('body')
                .append($('<p>').text(`${bug.description}`));

            const title = $('<div>')
                .addClass('title')
                .append($('<span>').addClass('author').text(`${bug.author}`))
                .append($('<span>').addClass('status').text(`Open | ${bug.severity}`));

            newReport.append(body);
            newReport.append(title);
            container.append(newReport);
        }
    }
}

const tracker = bugReportModule();

tracker.output('#content');
tracker.report('guy', 'report content', true, 5);
tracker.report('second guy', 'report content 2', true, 3);
tracker.report('abv', 'report content three', true, 4);
tracker.sort('author');
export const judokaSettings = {
    columns: { 
        firstName: {
            title: 'First Name',
            filter: false,
        },
        lastName: {
            title: 'Last Name',
            filter: false,
        },
        gender: {
            title: 'gender',
            filter: false,
            type: 'html',
            valuePrepareFunction : (cell, row) => {       
            let status = cell;
            let result = '';
            if (status == 0)
            {
                result = 'Man';
            }
            else if(status == 1)
            {
                result = 'Woman'
            }
            return result;
            }
        },  
        danKyu: {
            title: 'danKyu',
            filter: false,
        },         
    },
    actions: {
        select: true,
        edit: true,
        add: false,
        delete: true,
        position: 'right',
      },
    pager: {
        perPage: 100
    }
};

export function init(id, group, pull, put, sort, handle, filter, component) {
    var sortable = new Sortable(document.getElementById(id), {
        animation: 200,
        group: {
            name: group,
            pull: pull || true,
            put: put
        },
        filter: filter || undefined,
        sort: sort,
        forceFallback: true,
        handle: handle || undefined,
        onRemove: (event) => {
            if (event.pullMode === 'clone') {
                // Remove the clone
                event.clone.remove();
            }
            
            component.invokeMethodAsync('UpdateCustomDotNetList', event.to.childNodes[1].innerText, event.item.id);
        }
    });
}

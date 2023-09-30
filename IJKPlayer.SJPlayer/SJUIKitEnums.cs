using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace IJKPlayer.SJPlayer
{    
    /*
    [Native]
    public enum SJUTVerticalAlignment : ulong
    {
        Default = 0,
        Center = 1
    }

    [Native]
    public enum SJAttributeRegexpInsertPosition : ulong
    {
        Left,
        Right
    }

    static class SJUIKitCFunctions
    {
        // extern NSMutableAttributedString * _Nonnull sj_makeAttributesString (void (^ _Nonnull)(SJAttributeWorker * _Nonnull) block);
        //[DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //static extern NSMutableAttributedString sj_makeAttributesString(SJAttributeWorkerArgumentAction block);

        // extern NSMutableAttributedString * _Nonnull sj_makeAttributesString (void (^ _Nonnull)(SJAttributeWorker *) block);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSMutableAttributedString sj_makeAttributesString(SJAttributeWorkerArgumentAction? block);

        // extern BOOL SJUTRangeContains (NSRange main, NSRange sub);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern bool SJUTRangeContains(NSRange main, NSRange sub);

        // extern NSRange SJUTGetTextRange (NSAttributedString * _Nonnull text);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSRange SJUTGetTextRange(NSAttributedString text);

        // extern SJKVOObserverToken sjkvo_observe (id _Nonnull target, NSString * _Nonnull keyPath, SJKVOObservedChangeHandler _Nonnull handler);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern nint sjkvo_observe(NSObject target, NSString keyPath, SJKVOObservedChangeHandler handler);

        // extern SJKVOObserverToken sjkvo_observe (id _Nonnull target, NSString * _Nonnull keyPath, NSKeyValueObservingOptions options, SJKVOObservedChangeHandler _Nonnull handler) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern nint sjkvo_observe(NSObject target, NSString keyPath, NSKeyValueObservingOptions options, SJKVOObservedChangeHandler handler);

        // extern void sjkvo_remove (id _Nonnull target, SJKVOObserverToken token);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sjkvo_remove(NSObject target, nint token);

        // extern NSString * _Nonnull sj_sqlite3_obj_get_default_table_name (Class _Nonnull cls);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_obj_get_default_table_name(Class cls);

        // extern id _Nonnull sj_sqlite3_obj_filter_obj_value (id _Nonnull value);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSObject sj_sqlite3_obj_filter_obj_value(NSObject value);

        // extern NSString * _Nonnull sj_sqlite3_stmt_create_table (SJSQLiteTableInfo * _Nonnull table);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_create_table(SJSQLiteTableInfo table);

        // extern NSString * _Nonnull sj_sqlite3_stmt_insert_or_update (SJSQLiteObjectInfo * _Nonnull objInfo);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_insert_or_update(SJSQLiteObjectInfo objInfo);

        // extern NSString * _Nonnull sj_sqlite3_stmt_get_column_value (SJSQLiteColumnInfo * _Nonnull column, id _Nonnull value);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_get_column_value(SJSQLiteColumnInfo column, NSObject value);

        // extern NSString * _Nullable sj_sqlite3_stmt_get_primary_values_json_string (NSArray * _Nonnull models, NSString * _Nonnull primaryKey);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke), Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        static extern NSString sj_sqlite3_stmt_get_primary_values_json_string(NSObject[] models, NSString primaryKey);

        // extern NSArray<id> * _Nullable sj_sqlite3_stmt_get_primary_values_array (NSString * _Nonnull jsonString);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //[return: NullAllowed]
        static extern NSObject[] sj_sqlite3_stmt_get_primary_values_array(NSString jsonString);

        // extern NSString * _Nonnull sj_sqlite3_stmt_get_last_row (SJSQLiteTableInfo * _Nonnull table);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_get_last_row(SJSQLiteTableInfo table);

        // extern int sj_sqlite3_obj_exec_each_result_callback (void * _Nonnull para, int ncolumn, char * _Nullable * _Nullable columnvalue, char * _Nullable * _Nullable columnname);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe int sj_sqlite3_obj_exec_each_result_callback(void* para, int ncolumn, sbyte** columnvalue, sbyte** columnname);

        // extern BOOL sj_sqlite3_obj_open_database (NSString * _Nonnull path, void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe bool sj_sqlite3_obj_open_database(NSString path, void* db);

        // extern BOOL sj_sqlite3_obj_close_database (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe bool sj_sqlite3_obj_close_database(void* db);

        // extern NSArray<NSDictionary *> * _Nullable sj_sqlite3_obj_exec (void * _Nonnull db, NSString * _Nonnull sql, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //[return: NullAllowed]
        static extern unsafe NSDictionary[] sj_sqlite3_obj_exec(void* db, NSString sql, out NSError error);

        // extern void sj_sqlite3_obj_begin_transaction (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_begin_transaction(void* db);

        // extern void sj_sqlite3_obj_commit (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_commit(void* db);

        // extern void sj_sqlite3_obj_rollback (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_rollback(void* db);

        // extern BOOL sj_sqlite3_obj_table_exists (void * _Nonnull db, NSString * _Nonnull name);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe bool sj_sqlite3_obj_table_exists(void* db, NSString name);

        // extern void sj_sqlite3_obj_drop_table (void * _Nonnull db, NSString * _Nonnull name, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_drop_table(void* db, NSString name, out NSError error);

        // extern void sj_sqlite3_obj_delete_row_datas (void * _Nonnull db, SJSQLiteTableInfo * _Nonnull table, NSArray<id> * _Nonnull primaryKeyValues, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_delete_row_datas(void* db, SJSQLiteTableInfo table, NSObject[] primaryKeyValues, out NSError error);

        // extern NSDictionary * _Nullable sj_sqlite3_obj_get_row_data (void * _Nonnull db, SJSQLiteTableInfo * _Nonnull table, id _Nonnull primaryKeyValue, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //[return: NullAllowed]
        static extern unsafe NSDictionary sj_sqlite3_obj_get_row_data(void* db, SJSQLiteTableInfo table, NSObject primaryKeyValue, out NSError error);

        // extern NSArray<id> * _Nonnull SJFoundationExtendedValuesForKey (NSString * _Nonnull key, NSArray<NSDictionary *> * _Nonnull array);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSObject[] SJFoundationExtendedValuesForKey(NSString key, NSDictionary[] array);

        // extern NSError * _Nonnull sqlite3_error_make_error (NSString * _Nonnull error_msg);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_make_error(NSString error_msg);

        // extern NSError * _Nonnull sqlite3_error_get_table_failed (Class _Nonnull cls);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_get_table_failed(Class cls);

        // extern NSError * _Nonnull sqlite3_error_get_column_failed (Class _Nonnull cls);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_get_column_failed(Class cls);

        // extern NSError * _Nonnull sqlite3_error_invalid_parameter ();
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_invalid_parameter();
    }

    [Native]
    public enum SJPresentationPriority : ulong
    {
        Droppable,
        Low,
        Normal,
        High,
        VeryHigh
    }

    [Native]
    public enum SJSQLite3Relation : long
    {
        LessThanOrEqual = -1,
        Equal,
        GreaterThanOrEqual,
        Unequal,
        LessThan,
        GreaterThan
    }
    */
}

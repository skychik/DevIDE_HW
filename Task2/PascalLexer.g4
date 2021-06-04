lexer grammar PascalLexer;

//PROGRAM: (RESERVED_WORD | COMMENT | LABELV | NUMBER | CHARACTER_STRING | SEPARATOR)+;

fragment A:('a'|'A');
fragment B:('b'|'B');
fragment C:('c'|'C');
fragment D:('d'|'D');
fragment E:('e'|'E');
fragment F:('f'|'F');
fragment G:('g'|'G');
fragment H:('h'|'H');
fragment I:('i'|'I');
fragment J:('j'|'J');
fragment K:('k'|'K');
fragment L:('l'|'L');
fragment M:('m'|'M');
fragment N:('n'|'N');
fragment O:('o'|'O');
fragment P:('p'|'P');
fragment Q:('q'|'Q');
fragment R:('r'|'R');
fragment S:('s'|'S');
fragment T:('t'|'T');
fragment U:('u'|'U');
fragment V:('v'|'V');
fragment W:('w'|'W');
fragment X:('x'|'X');
fragment Y:('y'|'Y');
fragment Z:('z'|'Z');

RESERVED_WORD: ABSOLUTE | AND | ARRAY | AS | ASM | BEGIN | CASE | CLASS | CONST | CONSTRUCTOR | 
               DESTRUCTOR | DISPINTERFACE | DIV | DO | DOWNTO | ELSE | END | EXCEPT | EXPORTS | FILE | 
               FINALIZATION | FINALLY | FOR | FUNCTION | GOTO | IF | IMPLEMENTATION | IN | INHERITED | 
               INITIALIZATION | INLINE | INTERFACE | IS | LABEL | LIBRARY | MOD | NIL | NOT | OBJECT | 
               OF | ON | OPERATOR | OR | OUT | PACKED | PROCEDURE | PROGRAM | PROPERTY | RAISE | 
               RECORD | REINTRODUCE | REPEAT | RESOURCESTRING | SELF | SET | SHL | SHR | STRING | THEN | 
               THREADVAR | TO | TRY | TYPE | UNIT | UNTIL | USES | VAR | WHILE | WITH | XOR;

ABSOLUTE: A B S O L U T E;
AND: A N D;
ARRAY: A R R A Y;
AS: A S;
ASM: A S M;
BEGIN: B E G I N;
CASE: C A S E;
CLASS: C L A S S;
CONST: C O N S T;
CONSTRUCTOR: C O N S T R U C T O R;
DESTRUCTOR: D E S T R U C T O R;
DISPINTERFACE: D I S P I N T E R F A C E;
DIV: D I V;
DO: D O;
DOWNTO: D O W N T O;
ELSE: E L S E;
END: E N D;
EXCEPT: E X C E P T;
EXPORTS: E X P O R T S;
FILE: F I L E;
FINALIZATION: F I N A L I Z A T I O N;
FINALLY: F I N A L L Y;
FOR: F O R;
FUNCTION: F U N C T I O N;
GOTO: G O T O;
IF: I F;
IMPLEMENTATION: I M P L E M E N T A T I O N;
IN: I N;
INHERITED: I N H E R I T E D;
INITIALIZATION: I N I T I A L I Z A T I O N;
INLINE: I N L I N E ;
INTERFACE: I N T E R F A C E;
IS: I S;
LABEL:  L A B E L;
LIBRARY: L I B R A R Y;
MOD: M O D;
NIL: N I L;
NOT: N O T;
OBJECT: O B J E C T;
OF: O F;
ON: O N;
OPERATOR: O P E R A T O R;
OR: O R;
OUT: O U T;
PACKED: P A C K E D;
PROCEDURE: P R O C E D U R E;
PROGRAM: P R O G R A M;
PROPERTY: P R O P E R T Y;
RAISE: R A I S E;
RECORD: R E C O R D;
REINTRODUCE: R E I N T R O D U C E;
REPEAT: R E P E A T;
RESOURCESTRING: R E S O U R C E S T R I N G;
SELF: S E L F;
SET: S E T;
SHL: S H L;
SHR: S H R;
STRING: S T R I N G;
THEN: T H E N;
THREADVAR: T H R E A D V A R;
TO: T O;
TRY: T R Y;
TYPE: T Y P E;
UNIT: U N I T;
UNTIL: U N T I L;
USES: U S E S;
VAR: V A R;
WHILE: W H I L E;
WITH: W I T H;
XOR: X O R;

fragment NEWLINE: '\r'? '\n';
SEPARATOR: [ \r\t\n]+ -> skip; 

fragment RECOGNIZED_SYMBOLS: (LETTER | DIGIT | HEX_DIGIT);
fragment LETTER: [a-zA-Z];
fragment DIGIT: [0-9];
fragment HEX_DIGIT: [a-fA-F0-9];

COMMENT: SINGLE_LINE_COMMENT | MULTIPLE_LINE_COMMENT | MULTIPLE_LINE_COMMENT2;
fragment SINGLE_LINE_COMMENT: DOUBLE_SLASH ~[\r\n]*;
fragment MULTIPLE_LINE_COMMENT: COMMENT_BRACE_OPEN .*? COMMENT_BRACE_CLOSE;
fragment MULTIPLE_LINE_COMMENT2: COMMENT_BRACE_ALT_OPEN .*? COMMENT_BRACE_ALT_CLOSE;

IDENTIFIER: (LETTER | '_') (LETTER | '_' | DIGIT)*;

//NUMBER: UNSIGNED_NUMBER | SIGNED_NUMBER;
SIGNED_NUMBER: SIGN? UNSIGNED_NUMBER;
fragment UNSIGNED_NUMBER: UNSIGNED_REAL | UNSIGNED_INTEGER;
fragment UNSIGNED_INTEGER: DIGIT_SEQUENCE | DOLLAR HEX_DIGIT_SEQUENCE | AMPER OCTAL_DIGIT_SEQUENCE | PERCENT BIN_DIGIT_SEQUENCE;
fragment SIGN: PLUS | MINUS;
fragment UNSIGNED_REAL: DIGIT_SEQUENCE ('.' DIGIT_SEQUENCE)? SCALE_FACTOR? ;
fragment SCALE_FACTOR: ('E' | 'e') SIGN? DIGIT_SEQUENCE;
fragment HEX_DIGIT_SEQUENCE: HEX_DIGIT+;
fragment OCTAL_DIGIT_SEQUENCE: [0-7]+;
fragment BIN_DIGIT_SEQUENCE: [0-1]+;
fragment DIGIT_SEQUENCE: DIGIT+;

LABELV: DIGIT_SEQUENCE | IDENTIFIER; 

CHARACTER_STRING: (QUOTED_STRING | CONTROL_STRING)+;
fragment QUOTED_STRING: QUOTE STRING_CHARACTER* QUOTE;
fragment STRING_CHARACTER: (QUOTE QUOTE) | (~['\n\r]);
fragment CONTROL_STRING: ('#' UNSIGNED_INTEGER)+;

fragment QUOTE: '\''; 
PLUS: '+';
MINUS: '-';
MUL: '*';
SLASH: '/';
EQ: '=';
LT: '<';
MT: '>';
SBRACE_OPEN: '[';
SBRACE_CLOSE: ']';
DOT: '.';
COMMA: ',';
PARENTH_OPEN: '(';
PARENTH_CLOSE: ')';
COLON: ':';
CAP: '^';
AT: '@';
fragment COMMENT_BRACE_OPEN: '{';
fragment COMMENT_BRACE_CLOSE: '}';
fragment DOLLAR: '$';
fragment HASH: '#';
fragment AMPER: '&';
fragment PERCENT: '%';
LT_DOUBLE: '<<'; 
MT_DOUBLE: '>>';
POW: '**';
NE: '<>';
CHINEE: '><';
ASSIGN_LT: '<=';
ASSIGN_MT: '>=';
ASSING: ':=';
ASSING_PLUS: '+=';
ASSING_MINUS: '-=';
ASSING_MUL: '*=';
ASSING_DIV: '/=';
SEP: ';';
fragment COMMENT_BRACE_ALT_OPEN: '(*';
fragment COMMENT_BRACE_ALT_CLOSE: '*)';
fragment CBRACE_ALT_OPEN: '(.';
fragment CBRACE_ALT_CLOSE: '.)';
fragment DOUBLE_SLASH: '//';
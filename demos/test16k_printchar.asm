    .org $bfff

main:
    lda #$00
    sta $6001
    lda #$09
    sta $6000
    jmp loop

loop:
    dec $6000
    lda $6000
    cmp $6001
    beq die
    jsr prog
    jmp loop

die:
    brk
    
prog:
    jsr deadfood
    rts

badfood:
    lda #$42
    jsr printchar
    lda #$41
    jsr printchar
    lda #$44
    jsr printchar
    lda #$46
    jsr printchar
    lda #$4F
    jsr printchar
    lda #$4F
    jsr printchar
    lda #$44
    jsr printchar
    rts

deadbeef:
    lda #$44
    jsr printchar
    lda #$45
    jsr printchar
    lda #$41
    jsr printchar
    lda #$44
    jsr printchar
    lda #$42
    jsr printchar
    lda #$45
    jsr printchar
    lda #$45
    jsr printchar
    lda #$46
    jsr printchar
    rts

deadfood:
    jsr deadbeef
    jsr newline
    jsr badfood
    jsr newline
    rts

newline:
    lda #$0D
    jsr printchar
    lda #$0A
    jsr printchar
    rts

printchar:
    tax
    stx $8100
    rts

    .org $fffc
    .word main
    .word $0000